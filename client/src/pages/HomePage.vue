<script setup>
import { AppState } from '../AppState.js';
import KeepCard from '../components/KeepCard.vue';
import CreateKeepForm from '../components/CreateKeepFrom.vue';
import { keepsService } from '../services/KeepsService.js';
import Pop from '../utils/Pop.js';
import { computed, onMounted } from 'vue';
import KeepModal from '../components/KeepModel.vue'

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
  <div class="container">
    <div class="row">
      <div v-for="keep in keeps" :key="keep.id" class="img-card col-md-3 col-6 pb-2 ">
        <KeepCard :keepProps="keep" />
      </div>
    </div>
  </div>
  <KeepModal />
  <CreateKeepForm />
</template>

<style scoped lang="scss"></style>
