import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Course } from './course.model';

@Component({
  selector: 'app-course',
  imports: [CommonModule],
  templateUrl: './course.component.html',
  styleUrl: './course.component.css'
})
export class CourseCatalog {
courses: Course[] = [
    {
      id: 1,
      title: 'Angular Basics',
      instructor: 'John Doe',
      startDate: new Date(2025, 6, 5),
      price: 2999.99,
      description: 'Learn the basics of Angular including components, modules, and data binding.'
    },
    {
      id: 2,
      title: 'Advanced TypeScript',
      instructor: 'Jane Smith',
      startDate: new Date(2025, 6, 10),
      price: 3499,
      description: 'Deep dive into TypeScript for building robust Angular applications.'
    }
  ];
}
