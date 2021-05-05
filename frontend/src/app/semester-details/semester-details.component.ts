import { Component, OnInit } from '@angular/core';
import { ApiService } from '../api.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-semester-details',
  templateUrl: './semester-details.component.html',
  styleUrls: ['./semester-details.component.scss'],
})
export class SemesterDetailsComponent implements OnInit {
  semesterID;
  semester;
  editing = false;

  constructor(private api: ApiService, private route: ActivatedRoute, private router: Router) {}

  ngOnInit(): void {
    this.semesterID = this.route.snapshot.paramMap.get('id');
    this.load();
  }

  deleteSemester() {
    this.api.deleteSemester(this.semesterID).subscribe(resp => {
      this.router.navigateByUrl("/list");
    });
  }

  saveSemester() {
    this.api.editSemester(this.semesterID, this.semester.megnevezes).subscribe(() => {
      this.load();
      this.editing = false;
    });
  }

  load() {
    this.api.getSemesterDetails(this.semesterID).subscribe((resp) => {
      this.semester = resp;
    });
  }

  back() {
    this.router.navigateByUrl("/list");
  }
}
