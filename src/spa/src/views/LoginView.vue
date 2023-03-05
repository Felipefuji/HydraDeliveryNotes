<template>
    <div class="home">
        <LoginForm></LoginForm>
    </div>
</template>

<script lang="ts">
import LoginForm from '@/components/Login/LoginForm.vue'

export default {
    name: 'LoginView',
    components: {
        LoginForm
    },
};
</script>