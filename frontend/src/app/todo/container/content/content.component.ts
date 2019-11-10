import { Component, OnInit } from '@angular/core';
import { Todo } from '@app/models/todo';
import { TodoService } from 'src/app/core/services/todo.service';

@Component({
  selector: 'app-content',
  templateUrl: './content.component.html',
  styleUrls: ['./content.component.css']
})
export class ContentComponent implements OnInit {
  items: Todo[];
  doneItems: Todo[];

  constructor(private service: TodoService) {}

  ngOnInit() {
    this.getData();
  }

  addTodo(item: string) {
    this.service.addItem(item).subscribe(() => this.getData());
  }

  markAsDone(item: Todo) {
    this.service.updateItem(item).subscribe(() => this.getData());
  }

  private getData() {
    this.service.getItems().subscribe(items => {
      this.items = items.filter(x => !x.done);
      this.doneItems = items.filter(x => x.done);
    });
  }
}
