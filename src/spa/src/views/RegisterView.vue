<template>
    <div class="home">
        <RegistryForm></RegistryForm>
    </div>
</template>

<script lang="ts">
import RegistryForm from '@/components/Login/RegistryForm.vue'

export default {
  name: 'RegisterView',
  components: {
    RegistryForm
  }
}
</script>