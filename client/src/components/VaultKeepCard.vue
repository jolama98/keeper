<script setup>
import { AppState } from '@/AppState.js';
import { VaultKeep } from '@/models/VaultKeep.js';

const props = defineProps({
  vaultProp: { type: VaultKeep, required: true }
})
</script>


<template>
  <div v-if="vaultProp">
    <p class="text-dark justify-content-center d-flex">{{ vaultProp?.name }}</p>
  </div>
</template>


<style lang="scss" scoped></style>
