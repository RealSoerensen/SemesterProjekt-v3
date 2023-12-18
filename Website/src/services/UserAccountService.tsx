import axios from "axios";
import { UserAccount } from "../models/UserAccount";
import baseURL from "./Constants";

const url = `${baseURL}/api/UserAccount`;

export async function update(userAccount: UserAccount): Promise<boolean> {
    try {
        console.log(userAccount);
        const response = await axios.put(`${url}`, userAccount);
        return response.status === 200;
    }
    catch (e) {
        console.error(e);
        return false;
    }
}