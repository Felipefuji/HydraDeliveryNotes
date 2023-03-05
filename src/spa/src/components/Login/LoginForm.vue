<template>
    <div class="container">
        <form @submit.prevent="login">
            <h2 class="mb-3">Login</h2>
            <div class="input">
                <label for="email">Email address</label>
                <input class="form-control"
                       name="email"
                       v-model="dataUserLogin.email"
                       placeholder="email@adress.com" />
            </div>
            <div class="input">
                <label for="password">Password</label>
                <input class="form-control"
                       type="password"
                       name="password"
                       v-model="dataUserLogin.password"
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
import { UserDataLogin } from '@/services/userInterfaces';
import { userService } from '@/services/userservices';
import { defineComponent, Ref, ref } from 'vue'
import { useRouter } from 'vue-router'

export default defineComponent({
    name: 'LoginForm',
    setup() {  
        const dataUserLogin: Ref<UserDataLogin> = ref({
            email: '',
            password: '',
        });     
        const router = useRouter();
        
        function login() {
            userService.login(dataUserLogin.value.email, dataUserLogin.value.password)
            .then(() => {
                router.push("/dashboard");
            })
            .catch((error: any) => {
                const errorCode = error.code;
                const errorMessage = error.message;
                console.log(errorCode);
                console.log(errorMessage);
            });
        }

        function moveToRegister(){
            router.push("/register");
        }

        return{
            dataUserLogin,
            login,
            moveToRegister
        }
    },
});
</script>