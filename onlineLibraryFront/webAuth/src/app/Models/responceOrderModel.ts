import { responceBookModel } from "./responceBookModel";
import { User } from "./user";

export class responceOrderModel
{
    id: number;
    condition: boolean;
    book: responceBookModel;
    user: User;
}   