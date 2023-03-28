import { IMansionApiResponse, IMansionResult } from "./IMansionApiResonse";

export class MansionApiResolve implements IMansionApiResponse {
    public id!: string;
    public statuscode!: string;
    public errormessages!: string[];
    public result!: IMansionResult[];

    public constructor(init?:Partial<MansionApiResolve>) {
        Object.assign(this, init);
    }
}