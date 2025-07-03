import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { Book } from '../book.model';

@Component({
  selector: 'app-booklist',
  imports: [CommonModule,RouterModule],
  templateUrl: './booklist.component.html',
  styleUrl: './booklist.component.css'
})
export class BooklistComponent {
books: Book[] = [
    { id: 1, title: 'Angular Basics', author: 'John Doe', price: 299, description: 'Intro to Angular...' },
    { id: 2, title: 'TypeScript Mastery', author: 'Max Programmer', price: 499, description: 'Deep dive into TS...' },
    { id: 3, title: 'RxJS Deep Dive', author: 'Sarah Streams', price: 399, description: 'Reactive programming with RxJS' },
  ];
}
