import { ApplicationConfig, provideBrowserGlobalErrorListeners, provideZoneChangeDetection } from '@angular/core';
import { provideRouter,Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { BooklistComponent } from './booklist/booklist.component';
import { BookdetailsComponent } from './bookdetails/bookdetails.component';
import { routes } from './app.routes';

const myRoutes:Routes=[
  {path:'',component:HomeComponent},
  {path:'books',component:BooklistComponent},
  {path:'books/:id',component:BookdetailsComponent}
];

export const appConfig: ApplicationConfig = {
  providers: [provideZoneChangeDetection({ eventCoalescing: true }), provideRouter(myRoutes)]
};
