import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";
import { InspectionsComponent } from "./Inspections/inspections/inspections.component";

const routes: Routes = [{path: '', component: InspectionsComponent}];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
