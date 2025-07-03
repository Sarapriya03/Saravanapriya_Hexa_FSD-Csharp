import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { StudentFeedbackComponent } from './student-feedback/student-feedback.component';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet,StudentFeedbackComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class App {
  title = 'student-feedback-form-app';
}
