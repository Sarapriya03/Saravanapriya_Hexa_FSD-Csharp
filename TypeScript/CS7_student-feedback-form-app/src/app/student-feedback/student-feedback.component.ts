import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { StudentFeedback } from './student-feedback.model'

@Component({
  selector: 'app-student-feedback',
  imports: [CommonModule,FormsModule],
  templateUrl: './student-feedback.component.html',
  styleUrl: './student-feedback.component.css'
})
export class StudentFeedbackComponent {
feedback: StudentFeedback = {
    studentName: '',
    courseName: '',
    rating: 1,
    comments: ''
  };

  courses: string[] = ['Angular', 'React', 'Vue', 'Node.js'];
}
