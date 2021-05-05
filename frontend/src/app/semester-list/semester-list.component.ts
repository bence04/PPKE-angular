import { Component, OnInit } from '@angular/core';
import { ApiService } from '../api.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-semester-list',
  templateUrl: './semester-list.component.html',
  styleUrls: ['./semester-list.component.scss']
})
export class SemesterListComponent implements OnInit {
  semesterName = "";
  displayedColumns: string[] = ['ID', 'Megnevezés', 'Megnyitás'];
  dataSource;

  constructor(private api: ApiService, private router: Router) { }

  ngOnInit(): void {
    this.load();
  }

  saveSemester() {
    console.log(this.semesterName);
    this.api.setSemester(this.semesterName).subscribe(resp => {
      this.load();
      this.semesterName = "";
    });
  }

  load() {
    this.api.getSemesterList().subscribe(resp => {
      this.dataSource = resp;
    });
  }

  openSemester(id) {
    this.router.navigateByUrl("/details/" + id);
  }

}
