<template>
    <div class="container">
        <form @submit.prevent="register">
            <h2 class="mb-3">Register</h2>
            <div class="input">
                <label for="email">Email address</label>
                <input class="form-control"
                       name="email"
                       v-model="dataUser.email"
                       placeholder="email@adress.com" />
            </div>
            <div class="input">
                <label for="password">Password</label>
                <input class="form-control"
                       type="password"
                       name="password"
                       v-model="dataUser.password"
                       placeholder="password123" />
            </div>
            <div class="input">
                <label for="firstName">First Name</label>
                <input class="form-control"
                       name="firstName"
                       v-model="dataUser.firstName"
                       placeholder="asdf" />
            </div>
            <div class="input">
                <label for="lastName">Last Name</label>
                <input class="form-control"
                       name="lastName"
                       v-model="dataUser.lastName"
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
import { UserDataRegistry } from '@/services/userInterfaces';
import { userService } from '@/services/userservices';
import { defineComponent, Ref, ref } from 'vue';
import { useRouter } from 'vue-router';

export default defineComponent({
    name: 'RegistryForm',
    setup() {
        const dataUser: Ref<UserDataRegistry> = ref({
            email: '',
            password: '',
            firstName: '',
            lastName: ''
        });
        const router = useRouter();
        
        function register() {
            userService.register(dataUser.value)
            .then((userCredential) => {
                    const user = userCredential.user;
                    console.log(user);
                    console.log("Registration completed");
                    router.push("/");
            })
            .catch((error) => {
                    const errorCode = error.code;
                    const errorMessage = error.message;
                    console.log(errorCode);
                    console.log(errorMessage);
                });
        }

        function moveToLogin() {
            router.push("/");
        }

        return{
            dataUser,
            register,
            moveToLogin
        }
    },
});
</script>