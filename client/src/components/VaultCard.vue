<script setup>
import { Vault } from '@/models/Vault.js';

// const vaults = computed(() => AppState.vaults)
defineProps({
  vault: Vault

})
</script>

<template>
  <div>
    <img :src="vault.img" alt="">
  </div>
</template>

<style lang="scss" scoped></style>
