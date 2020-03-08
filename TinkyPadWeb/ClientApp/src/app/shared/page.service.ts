import { Injectable } from "@angular/core";

@Injectable()
export class PageService {
  pageIndex: number;

  setPage(pageIndex: number) {
    this.pageIndex = pageIndex;
  }
}