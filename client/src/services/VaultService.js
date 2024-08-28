import { logger } from "@/utils/Logger.js";
import { api } from "./AxiosService.js";
import { Vault } from "../models/Vault.js";
import { AppState } from "@/AppState.js";


class VaultService {

  // async getAllVaults() {
  //   const response = await api.get('api/vaults')
  //   logger.log('ALLLLLLL', response.data)
  // }

  // async getVaultsById(vaultId) {
  //   //                               /api/vaults/{{vaultId}}
  //   AppState.activeVaults = null
  //   const response = await api.get(`api/vaults/${vaultId}/keeps`)
  //   logger.log(response.data)
  //   const vault = new Vault(response.data)
  //   AppState.activeVaults = vault
  //   // //? Get vault by ID
  // }

}

export const vaultService = new VaultService();
