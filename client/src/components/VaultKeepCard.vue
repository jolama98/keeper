<script setup>
import { VaultKeep } from '@/models/VaultKeep.js';

const props = defineProps({
  vaultProp: { type: VaultKeep, required: true }
})
</script>


<template>
  <div v-if="vaultProp" class="card mb-1">
    <div class=" card-body d-flex flex-column justify-content-end">
      <div class=" text-bg rounded-5 d-flex justify-content-between">
        <p class="card-text text-light textShadow fs-4 m-1">{{ vaultProp?.name }}</p>
        <img :src="vaultProp?.img" alt="">

      </div>
    </div>
  </div>
</template>


<style lang="scss" scoped></style>
