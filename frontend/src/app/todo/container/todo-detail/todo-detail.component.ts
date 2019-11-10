import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Todo } from '@app/models/todo';
import { Observable } from 'rxjs';
import { TodoService } from '../../../core/services/todo.service';

@Component({
  selector: 'app-todo-detail',
  templateUrl: './todo-detail.component.html',
  styleUrls: ['./todo-detail.component.css']
})
export class TodoDetailComponent implements OnInit {
  todo$: Observable<Todo>;

  constructor(private route: ActivatedRoute, private service: TodoService) {}

  ngOnInit() {
    const id = this.route.snapshot.params.id;
    this.todo$ = this.service.getItem(id);
  }
}
