import { Pad } from "./pad.model";
import { Injectable } from "@angular/core";
import { PadProviderServiceMock } from "./pad-provider.service.mock";

@Injectable()
export class PadProviderService {

  constructor(private padProvider: PadProviderServiceMock) {}

  getPad(): Pad {
    return this.padProvider.getPad();
  }
}