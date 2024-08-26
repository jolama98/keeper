<script setup>
import { AppState } from '@/AppState.js';
import { computed } from 'vue';

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
                <div class="d-flex justify-content-md-end justify-content-center pt-5">
                  <p class="mdi mdi-eye">{{ keep.kept }}</p>
                </div>
              </div>
              <div class="col-md-6">
                <div class="d-flex justify-content-md-start justify-content-center pt-5">
                  <p class="mdi mdi-sack">{{ keep.kept }}</p>
                </div>
              </div>
            </div>
            <div class="row">
              <div class="align-self-center pt-5">
                <div class="col-12">
                  <div class="d-flex justify-content-center ">
                    <h1 class="modal-title fs-2" id="keepModal">{{ keep?.name }}</h1>
                  </div>
                  <div class="col-12">
                    <div class="d-flex justify-content-center">
                      <p>{{ keep?.description }}</p>
                    </div>
                  </div>
                </div>
              </div>
            </div>
            <div class="row">
              <div class="col-md-6">
                <div class="dropdown">
                  <div class="d-flex justify-content-around">

                    <a class="btn btn-light dropdown-toggle" href="#" role="button" data-bs-toggle="dropdown"
                      aria-expanded="false">
                      Dropdown link
                    </a>
                    <button class="btn btn-color btn-dark">Save</button>
                  </div>
                  <ul class="dropdown-menu">
                    <li><a class="dropdown-item" href="#">Action</a></li>
                    <li><a class="dropdown-item" href="#">Another action</a></li>
                    <li><a class="dropdown-item" href="#">Something else here</a></li>
                  </ul>
                </div>
              </div>
              <div class="col-md-6">
                <div class="d-flex align-items-center">
                  <img class="avatar p-1" :src="keep.creator?.picture" alt="">
                  <p class="m-0 creator-name">{{ keep.creator?.name }}</p>
                </div>
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

.creator-name {
  font-family: marko-one;
  font-weight: bold;
}

h1 {
  text-shadow: 1px 1px 1px rgb(255, 255, 255);
  font-family: marko-one;
  font-weight: bolder;
}

.avatar {
  vertical-align: middle;
  width: 50px;
  height: 50px;
  border-radius: 50%;
}

.btn-color {
  background-color: #877A8F;
}
</style>
