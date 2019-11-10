import {
  ChangeDetectionStrategy,
  Component,
  EventEmitter,
  Input,
  Output
} from '@angular/core';
import { Todo } from '@app/models/todo';

@Component({
  selector: 'app-todo-list',
  templateUrl: './todo-list.component.html',
  styleUrls: ['./todo-list.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class TodoListComponent {
  @Input() items: Todo[] = [];
  @Input() doneItems: Todo[] = [];

  @Output() markAsDone = new EventEmitter();

  showList = true;

  moveToDone(event: any, item: Todo) {
    event.preventDefault();
    event.stopPropagation();
    const copy = { ...item };
    copy.done = true;
    this.markAsDone.emit(copy);
  }

  toggleDoneList() {
    this.showList = !this.showList;
  }
}
