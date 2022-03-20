import { responceBookModel } from "./responceBookModel";

export class responceOrderModel
{
    id: number;
    condition: boolean;
    date: Date;
    book: responceBookModel;
}