import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { CommonModule } from '@angular/common';
import { Student } from './student/student.model';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, RouterOutlet], 
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'student-list-management-app';

  students: Student[] = [
    { name: 'Alice', marks: 85, status: true },
    { name: 'Bob', marks: 45, status: false },
    { name: 'Charlie', marks: 60, status: true },
    { name: 'David', marks: 30, status: false }
  ];
}
