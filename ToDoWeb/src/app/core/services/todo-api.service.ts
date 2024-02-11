import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, forkJoin, map, switchMap } from 'rxjs';
import { ToDoList } from '../models/todo-list.model';
import { environment } from 'src/environments/environment';
import { ToDoItem } from '../models/todo-item.model';

@Injectable({
  providedIn: 'root'
})
export class TodoApiService {
  apiUrl =  `${environment.API_URL}`;
    constructor(private httpClient: HttpClient) { }

  getAllToDoList(): Observable<ToDoList[]> {
    const url: string = `${this.apiUrl}/todo-lists`;

    return this.httpClient.get<ToDoList[]>(url);
  }

  getToDoItems(toDoListId: string): Observable<ToDoItem[]> {
    const url: string = `${this.apiUrl}/todo-items/todo-list/${toDoListId}`;

    return this.httpClient.get<ToDoItem[]>(url);
  }

  getToDoListsWithItems(): Observable<ToDoList[]> {
    return this.getAllToDoList()
    .pipe(
      switchMap(toDoLists => {
        const toDoListWithItem = toDoLists.map(toDoList => {
          return this.getToDoItems(toDoList.id)
          .pipe(
            map(toDoItems => ({...toDoList, items: toDoItems}))
          )});

        return forkJoin(toDoListWithItem);
      })
    )
  }

  markToDoItemAsDone(toDoItemId: string, isDone: boolean) {
    const url: string = `${this.apiUrl}/todo-items/${toDoItemId}/done/${isDone}`;

    return this.httpClient.patch<ToDoItem>(url, {});
  }
}

