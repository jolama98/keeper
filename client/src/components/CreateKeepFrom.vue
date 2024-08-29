<script setup>
import { keepsService } from '@/services/KeepsService.js';
import Pop from '@/utils/Pop.js';
import { Modal } from 'bootstrap';
import { ref } from 'vue';
import { useRoute } from 'vue-router';


const keepData = ref({
  img: '',
  description: '',
  name: ''
})

function resetForm() {
  keepData.value = {
    img: '',
    description: '',
    name: ''
  }
}

async function createKeep() {
  try {
    await keepsService.createKeep(keepData.value)
    keepData.value = {
      img: '',
      description: '',
      name: ''
    }
    Modal.getOrCreateInstance('#createKeepModal').hide()
    Pop.success('Report submitted!')
  }
  catch (error) {
    Pop.error(error);
  }
}
</script>

<template>
  <div class="modal fade" id="createKeepModal" tabindex="-1" aria-labelledby="keepModal" aria-hidden="true">
    <div class="modal-dialog modal-xl">
      <div class="modal-content">

        <form class="container-fluid" @submit.prevent="createKeep()">
          <section class="row">
            <h3>Add Keep</h3>

            <div class="mb-3">
              <label for="name" class="form-label">Keep Name</label>
              <input v-model="keepData.name" type="text" class="form-control" id="name" aria-describedby="nameKeep"
                required maxlength="20">
              <div id="nameKeep" class="form-text">Name Your Keep</div>
            </div>
            <div class="col-12 mb-3">
              <label for="keep-image-url">Image Url</label>
              <input v-model="keepData.img" class="form-control" type="url" name="keep-image-url" id="keep-image-url"
                required maxlength="1000">
            </div>
            <div class="mb-3">
              <label for="description" class="form-label">Description</label>
              <input v-model="keepData.description" type="text" class="form-control" id="description"
                aria-describedby="descriptionPeek" required maxlength="255">
              <div id="descriptionKeep" class="form-text">Description Of Keep</div>
            </div>
            <div class="col-12 text-center">
              <img v-if="keepData.img" :src="keepData.img" class="img-preview" alt="could not load image">
            </div>
            <div class="col-12 text-end">
              <button class="btn btn-primary m-2"><i class="mdi mdi-plus"></i>Submit</button>
            </div>
          </section>
        </form>
        <div class="modal-footer "></div>
      </div>
    </div>
  </div>
</template>


<style lang="scss" scoped></style>

<!-- this.name = data.name;
this.description = data.description;
this.img = data.img; -->
