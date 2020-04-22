import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ApiService } from 'src/app/shared/api.service';
import { AddSemesterComponent } from '../dialog/add-semester/add-semester.component';
import { EditSemesterComponent } from '../dialog/edit-semester/edit-semester.component';


@Component({
  selector: 'app-semesters',
  templateUrl: './semesters.component.html',
  styleUrls: ['./semesters.component.scss']
})
export class SemestersComponent implements OnInit {
  displayedColumns: string[] = ['id', 'name', 'startDate', 'actions'];
  dataSource;
  loading = true;
  constructor(public dialog: MatDialog, private apiService: ApiService) { }

  ngOnInit(): void {
    this.getSemesters();
  }

  getSemesters() {
    this.apiService.getSemester().subscribe((resp: any) => {
      this.loading = true;
      this.dataSource = resp.items.map(x => {
        return {
          id: x.id,
          name: x.megnevezes,
          startDate: x.kezdet
        };
      });
      this.loading = false;
    });
  }

  addNew() {
    const dialogRef = this.dialog.open(AddSemesterComponent, {
      width: '450px'
    });

    dialogRef.afterClosed().subscribe(result => {
      this.apiService.addSemester(result).subscribe(resp => {
        this.getSemesters();
        alert('Sikeres szemeszter hozzáadás!');
      });
    });
  }

  delete(id) {
    this.apiService.deleteSemester(id).subscribe(resp => {
      this.getSemesters();
      alert('Sikeres törlés');
    });
  }

  edit(element) {
    const dialogRef = this.dialog.open(EditSemesterComponent, {
      width: '450px',
      data: element
    });

    dialogRef.afterClosed().subscribe(result => {
      this.apiService.editSemester(element.id, result).subscribe(resp => {
        this.getSemesters();
        alert('Sikeres szemeszter frissítés!');
      });
    });
  }

}
