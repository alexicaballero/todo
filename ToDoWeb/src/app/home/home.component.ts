import { Component, OnInit } from '@angular/core';
import { TodoApiService } from '../core/services/todo-api.service';
import { ToDoList } from '../core/models/todo-list.model';
import { forkJoin, map, switchMap } from 'rxjs';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
})
export class HomeComponent implements OnInit {
  toDoLists: ToDoList[] = [];

  /**
   *
   */
  constructor(private readonly toDoApiService: TodoApiService) {}

  ngOnInit(): void {
    this.toDoApiService.getToDoListsWithItems().subscribe({
      next: (toDoLists: ToDoList[]) => {
        this.toDoLists = toDoLists;
      },
      error: (err) => {},
      complete: () => {},
    });
  }
}
