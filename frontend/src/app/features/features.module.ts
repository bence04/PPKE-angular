import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SemestersComponent } from './semesters/semesters.component';
import { FeaturesRoutingModule } from './features-routing.module';
import { SharedModule } from '../shared/shared.module';
import { AddSemesterComponent } from './dialog/add-semester/add-semester.component';
import { EditSemesterComponent } from './dialog/edit-semester/edit-semester.component';



@NgModule({
  declarations: [SemestersComponent, AddSemesterComponent, EditSemesterComponent],
  imports: [
    CommonModule,
    FeaturesRoutingModule,
    SharedModule
  ],
  entryComponents: [
    AddSemesterComponent,
    EditSemesterComponent
  ]
})
export class FeaturesModule { }
