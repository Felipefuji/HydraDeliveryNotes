<template>
    <div class="container">
        <form @submit.prevent="login">
            <h2 class="mb-3">Login</h2>
            <div class="input">
                <label for="email">Email address</label>
                <input class="form-control"
                       name="email"
                       v-model="email"
                       placeholder="email@adress.com" />
            </div>
            <div class="input">
                <label for="password">Password</label>
                <input class="form-control"
                       type="password"
                       name="password"
                       v-model="password"
                       placeholder="password123" />
            </div>
            <div class="alternative-option mt-4">
                You don't have an account? <span @click="moveToRegister">Register</span>
            </div>
            <button type="submit" class="mt-4 btn-pers" id="login_button">
                Login
            </button>
        </form>
    </div>
</template>

<script lang="ts">
import { userService } from '@/services/userservices';
import { defineComponent } from 'vue';

interface UserData {
    email: string,
    password: string
}

export default defineComponent({
    data(): UserData {
        return {
            email: "",
            password: "",
        };
    },
    methods: {
        login() {
            userService.login(this.email, this.password)
            .then(() => {
                this.$router.push("/dashboard");
            })
            .catch((error: any) => {
                const errorCode = error.code;
                const errorMessage = error.message;
                console.log(errorCode);
                console.log(errorMessage);
            });
        },
        moveToRegister() {
            this.$router.push("/register");
        },
    },
});
</script>