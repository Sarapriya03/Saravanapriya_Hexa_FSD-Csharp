import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { CourseCatalog } from './course/course.component';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet,CourseCatalog],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class App {
   title = 'course-catalog-display-app';
}
