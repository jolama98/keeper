import { logger } from "@/utils/Logger.js";
import { api } from "./AxiosService.js";
import { AppState } from "@/AppState.js";
import { VaultKeep } from "@/models/VaultKeep.js";

class VaultKeepService {
  // async createKeep(keepData) {
  //   const response = await api.post('api/keeps', keepData)
  //   const newKeep = new Keep(response.data)
  //   AppState.keeps.push(newKeep)
  // }

  async createVaultKeep(createVaultKeepData) {
    const response = await api.post('api/vaultkeeps', createVaultKeepData)
    logger.log(response.data)
    const vaultKeep = new VaultKeep(response.data)
    AppState.vaultKeeps.push(vaultKeep)
  }
}

export const vaultKeepService = new VaultKeepService;
