<template>
      <div class="text-center">You're now logged as</div>
      <div id="username_display" class="display-6">{{ email }}</div>
      <button id="sign_out" class="mt-4 btn btn-danger" @click="signOut">
        Logout
      </button>
</template>

<script lang="ts">
import { userService } from "@/services/userservices";
import { defineComponent, Ref, ref } from "vue";

export default defineComponent({
    name: 'DashboardWidget',
    setup() {
        const email: Ref<string> = ref('');

        function signOut() {
            userService.logout();
        }

        return{
            email,
            signOut
        }  
  },
});
</script>