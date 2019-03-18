import { ActionsType } from "./action-type";

export interface Action {
    type: ActionsType, //The thing we want to do
    payload?: any //The things we have done
}