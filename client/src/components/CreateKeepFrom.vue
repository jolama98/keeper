<script setup>
import { ref } from 'vue';
import { useRoute } from 'vue-router';

const route = useRoute()
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

function createKeep() {

}
</script>


<template>





  <div class="modal fade" id="createKeepModal" tabindex="-1" aria-labelledby="keepModal" aria-hidden="true">
    <div class="modal-dialog modal-xl">
      <div class="modal-content">

        <form class="container-fluid" @submit.prevent="createKeep()">
          <section class="row">
            <h3>Add Keep</h3>
            <div class="col-12 mb-3">
              <label for="keep-image-url">Image Url</label>
              <input v-model="keepData.img" class="form-control" type="url" name="keep-image-url" id="keep-image-url"
                required maxlength="1000">
            </div>
            <div class="col-12 text-center">
              <img v-if="keepData.img" :src="keepData.img" class="img-preview" alt="could not load image">
            </div>
            <div class="col-12 text-end">
              <button class="btn btn-primary"><i class="mdi mdi-plus"></i>Submit</button>
            </div>
          </section>
        </form>
      </div>
    </div>
  </div>






</template>


<style lang="scss" scoped></style>

<!-- this.name = data.name;
this.description = data.description;
this.img = data.img; -->
