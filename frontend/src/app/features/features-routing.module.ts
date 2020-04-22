import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { SemestersComponent } from './semesters/semesters.component';


const routes: Routes = [
  { path: '', component: SemestersComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class FeaturesRoutingModule { }
