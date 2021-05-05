import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { SemesterListComponent } from './semester-list/semester-list.component';
import { SemesterDetailsComponent } from './semester-details/semester-details.component';

const routes: Routes = [
  { path: '', redirectTo: 'list', pathMatch: 'full'},
  { path: 'list', component: SemesterListComponent },
  { path: 'details/:id', component: SemesterDetailsComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
