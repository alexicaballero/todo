import { Component, Input, OnInit } from '@angular/core';
import { ToDoList } from 'src/app/core/models/todo-list.model';
import { TodoApiService } from 'src/app/core/services/todo-api.service';

@Component({
  selector: 'app-todo-list',
  templateUrl: './todo-list.component.html',
  styleUrls: ['./todo-list.component.scss'],
})
export class TodoListComponent implements OnInit {
  @Input()
  toDoList: ToDoList | undefined;

  /**
   * constructor
   */
  constructor(private readonly todoApiService: TodoApiService) {}

  ngOnInit(): void {}

  onDoneClick(toDoItemId: string, isDone: boolean) {
    console.log('isDone: ', isDone);
    this.todoApiService.markToDoItemAsDone(toDoItemId, isDone).subscribe({
      next: (toDoItemResult) => {
        const toDoItem = this.toDoList?.items.find(
          (item) => item.id === toDoItemId
        );
        if (toDoItem) {
          toDoItem.done = toDoItemResult.done;
        }
      },
      error: (err) => {},
      complete: () => {},
    });
  }

  onDeleteClick(toDoItemId: string) {
    this.todoApiService.deleteToDoItem(toDoItemId).subscribe({
      next: () => {
        const toDoItem = this.toDoList?.items.find(
          (item) => item.id === toDoItemId
        );
        if (toDoItem && this.toDoList) {
          this.toDoList.items = this.toDoList?.items.filter(
            (item) => item.id !== toDoItemId
          );
        }
      },
      error: (err) => {},
      complete: () => {},
    });
  }
}
