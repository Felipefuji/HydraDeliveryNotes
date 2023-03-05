<template>
    <div class="container">
        <form @submit.prevent="register">
            <h2 class="mb-3">Register</h2>
            <div>
                <label for="email">Email address</label>
                <input class="form-control"
                       name="email"
                       v-model="email"
                       placeholder="email@adress.com" />
            </div>
            <div>
                <label for="password">Password</label>
                <input class="form-control"
                       type="password"
                       name="password"
                       v-model="password"
                       placeholder="password123" />
            </div>
            <div>
                <label for="firstName">First Name</label>
                <input class="form-control"
                       name="firstName"
                       v-model="firstName"
                       placeholder="asdf" />
            </div>
            <div>
                <label for="lastName">Last Name</label>
                <input class="form-control"
                       name="lastName"
                       v-model="lastName"
                       placeholder="asdf" />
            </div>
            <div class="alternative-option mt-4">
                Already have an account? <span @click="moveToLogin">Login</span>
            </div>
            <button type="submit" value="register" id="register_button" class="mt-4 btn-pers">
                Register
            </button>
        </form>
    </div>
</template>

<script lang="ts">
import { userService } from '@/services/userservices';
import { defineComponent } from 'vue';

interface Data {
    email: string,
    password: string,
    firstName: string | null,
    lastName: string | null
}

export default defineComponent({
    data(): Data {
        return {
            email: "",
            password: "",
            firstName: null,
            lastName: null
        };
    },
    methods: {
        register() {
            const post = {
                email: this.email,
                password: this.password,
                firstName: this.firstName,
                lastName: this.lastName
            }
            userService.register(post)
            .then((userCredential) => {
                    const user = userCredential.user;
                    console.log(user);
                    console.log("Registration completed");
                    this.$router.push("/");
            })
            .catch((error) => {
                    const errorCode = error.code;
                    const errorMessage = error.message;
                    console.log(errorCode);
                    console.log(errorMessage);
                });
            },
        moveToLogin() {
            this.$router.push("/");
        },
    },
});
</script>