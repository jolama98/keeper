<script setup>
import { AppState } from '@/AppState.js';
import { computed } from 'vue';

// const project = computed(() => AppState.activeProject)
const keep = computed(() => AppState.setActiveKeep)

</script>


<template>

  <div class="modal fade" id="keepModal" tabindex="-1" aria-labelledby="keepModal" aria-hidden="true">
    <div class="modal-dialog  modal-xl">
      <div class="modal-content">
        <div class="row">
          <div class="col-md-6">
            <img class="keep-img img-fluid flex-grow-1" :src="keep.img" :alt="keep.name">
          </div>
          <div class="col-md-6">
            <div class="row">
              <div class="col-md-6">
                <div class="d-flex justify-content-end pt-5">
                  <p class="mdi mdi-eye">999</p>
                </div>
              </div>
              <div class="col-md-6">
                <div class="d-flex justify-content-start pt-5">
                  <p class="mdi mdi-sack">666</p>
                </div>
              </div>
            </div>
            <div class="row">
              <div class="col-12">
                <div class="d-flex justify-content-center">
                  <h1 class="modal-title fs-2" id="keepModal">{{ keep?.name }}</h1>
                </div>
                <p>{{ keep?.description }}</p>
              </div>
            </div>
          </div>

        </div>
      </div>
    </div>
  </div>
</template>


<style lang="scss" scoped>
.keep-img {
  height: 100%;
  background-position: center;
  background-size: cover;
}

h1 {
  text-shadow: 1px 1px 1px rgb(255, 255, 255);
  font-family: marko-one;
  font-weight: bolder;
}
</style>
