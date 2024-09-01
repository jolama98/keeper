<script setup lang="ts">
import { AppState } from '../AppState.js';
import KeepCard from '../components/KeepCard.vue';
import CreateKeepForm from '../components/CreateKeepFrom.vue';
import { keepsService } from '../services/KeepsService.js';
import Pop from '../utils/Pop.js';
import { computed, onMounted } from 'vue';
import CreateVaultForm from '@/components/CreateVaultForm.vue';


const keeps = computed(() => AppState.keeps)

onMounted(() => {
  gatAllKeeps()
})


async function gatAllKeeps() {
  try {
    await keepsService.getAllKeeps()
  }
  catch (error) {
    Pop.error(error);
  }
}

</script>

<template>
  <div class="container bg-body-secondary">
    <div class="row">
      <div v-for="keep in keeps" :key="keep.id" class="img-card col-md-3 col-6 pb-1  grid pt-3">
        <KeepCard :keepProps="keep" class="item" />
        <KeepCard :keepProps="keep" class="item" />
      </div>
    </div>
  </div>

  <CreateKeepForm />
  <CreateVaultForm />
</template>

<style scoped lang="scss">
* {
  box-sizing: border-box;
}

.grid {
  columns: 18rem;
  gap: 1rem;
  counter-reset: grid;
}

.item+.item {
  margin-top: 1rem;
}

.item {
  break-inside: avoid;
  aspect-ratio: 4 / 3;

  padding: 1rem;
  border-radius: 0.75rem;
}

.item::before {
  counter-increment: grid;
  content: counter(grid);
}

.item:nth-child(3n) {
  aspect-ratio: 1;
  background: lavender;
}

.item:nth-child(3n - 1) {
  aspect-ratio: 2 / 3;

}
</style>
