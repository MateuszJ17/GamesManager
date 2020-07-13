import {NgModule} from '@angular/core';
import {Routes, RouterModule} from '@angular/router';
import {MainComponent} from "./components/main/main.component";
import {GameFormComponent} from "./components/game-form/game-form.component";
import {GameDetailsComponent} from "./components/game-details/game-details.component";


const routes: Routes = [
  { path: '', component: MainComponent },
  { path: 'add', component: GameFormComponent },
  { path: 'edit/:id', component: GameFormComponent },
  { path: 'details/:id', component: GameDetailsComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {
}
