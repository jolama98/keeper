import { logger } from "@/utils/Logger.js";
import { api } from "./AxiosService.js";

class VaultService {

  async getVaultsByCreatorId(vaultId) {
    const response = await api.get(`api/values/${vaultId}`)
    logger.log(response.data)

  }
}

export const vaultService = new VaultService();
