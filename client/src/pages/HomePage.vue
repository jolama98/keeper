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
  <div class="container-fluid  mt-3">
    <div class="row">
      <div class="col-12">
        <div class="masonry-layout">

          <div v-for="keep in keeps" :key="keep.id" class="masonry-item">
            <KeepCard :keepProps="keep" />
          </div>

        </div>
      </div>
    </div>
  </div>

  <CreateKeepForm />
  <CreateVaultForm />
</template>

<style scoped lang="scss">
.masonry-layout {
  column-count: 4;
  column-gap: 1rem;
  width: 100%;
}

.masonry-item {
  break-inside: avoid;
  margin-bottom: 1rem;
}

@media (max-width: 768px) {
  .masonry-layout {
    column-count: 3;
  }
}

@media (max-width: 550px) {
  .masonry-layout {
    column-count: 2;
  }
}
</style>
