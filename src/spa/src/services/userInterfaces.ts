export interface UserDataRegistry {
    email: string;
    password: string;
    firstName: null | string;
    lastName: null | string;
}

export interface UserDataLogin {
    email: string;
    password: string;
}
