<template>
  <div>
    <DashboardWidget></DashboardWidget>
  </div>
</template>

<script lang="ts">
import DashboardWidget from "@/components/Dashboard/DashboardWidget.vue";

export default {
    name: "DashboardView",
    components: {
       DashboardWidget 
      }
};
</script>