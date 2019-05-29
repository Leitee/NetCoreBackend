import { Component, OnInit } from '@angular/core';
import { Student, Subject } from '@/_models';
import { BreakpointObserver } from '@angular/cdk/layout';
import { SchoolService } from '@/_services';
import { ActivatedRoute } from '@angular/router';
import { Utils } from '@/_commons';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-exam',
  templateUrl: './exam.component.html',
  styleUrls: ['../pages.component.scss'],
  providers: [SchoolService]
})
export class ExamComponent implements OnInit {

  studentListSource: Observable<Array<Student>>;
  subject: Subject;

  constructor(private schoolSvc: SchoolService, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.route.queryParams
      .subscribe((subj: Subject) => {
        this.subject = subj;
        console.log("passing",subj)
        this.studentListSource = this.schoolSvc.getStudentsExamsBySubjectId(subj.id);
      });
  }

  public get util() {
    return Utils;
  }

}