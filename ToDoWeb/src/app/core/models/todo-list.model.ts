import { ToDoItem } from "./todo-item.model";

export interface ToDoList {
  id: string;
  title: string;
  items: ToDoItem[];
}
