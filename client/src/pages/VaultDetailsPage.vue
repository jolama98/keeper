<script setup>
import { AppState } from '@/AppState.js';
import { computed, onMounted } from 'vue';

onMounted(() => {
  getKeepsInVault()
})

const vaults = computed(() => AppState.activeVaults)

function getKeepsInVault() {

}
</script>


<template>
  <h1>Vaults Details</h1>

  {{ vaults.name }}
</template>


<style lang="scss" scoped></style>
