<template>
  <div>
    <div class="text-center">You're now logged as</div>
    <div id="username_display" class="display-6">{{ email }}</div>
    <button id="sign_out" class="mt-4 btn btn-danger" @click="signOut">
      Logout
    </button>
  </div>
</template>

<script lang="ts">
import { userService } from "@/services/userservices";

export default {
  data() {
    return {
      email: 'pruebaEmail',
    };
  },
  methods: {
    signOut() {
      userService.logout();
    },
  },
};
</script>