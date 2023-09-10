import { Injectable } from "@angular/core";
import { FormArray, FormBuilder, FormGroup } from "@angular/forms";
import { environment } from "src/environments/environment";
import { HttpClient, HttpParams} from "@angular/common/http";
import { CreateGameDto, CreateGameGenreDto, CreateGameLocalizationDto, CreateGameModeDto, CreateGamePlayerPerspectiveDto, CreateGameThemeDto, CreateMultiplayerModeDto, CreateReleaseDateDto } from "../types/game/create-game";
import { GameSimpleDto } from "../types/game/GameSimpleDto";

@Injectable()
export class GameService{
  uri: string = 'Game'
  baseUrl = environment.apiUrl+this.uri;
  constructor(private readonly formBuilder: FormBuilder, private http: HttpClient){}

  initForm(): FormGroup {
      return this.formBuilder.group({
        general: this.formBuilder.group({
          name:[null],
          description:[null],
          image:[null],
          updateGameType: [null],
          updatedGameId:[null],
          gameStatus:[null],
          cover: [null],
          gameEdition:this.formBuilder.group({
            baseGame: [null],
            editionTitle: [null]
          }),
          gameAlternativeNames:this.formBuilder.array([])
        }),
        localization: this.formBuilder.array([]),
        categorization: this.formBuilder.group({
          genre:[null],
          theme:[null],
          perspectives:[null],
          gameMode:[null],
          multiplayerModes: this.formBuilder.array([])
        }),
        releaseDates: this.formBuilder.array([]),
        websites: this.formBuilder.group({
          steam: [null],
          epic: [null],
          appStorePhone: [null],
          itch: [null],
          gog:[null],
          googlePlay:[null],
          appStoreTablet: [null],
          official: [null],
          twitch: [null],
          youtube: [null],
          facebook: [null],
          twitter:[null],
          instagram:[null],
          discord: [null],
          reddit:[null]
        }),
        companies: this.formBuilder.array([]),
        storyline: [null],
        supportedLanguage: this.formBuilder.group({
          audio:[null],
          subtitle:[null],
          interface:[null]
        })
      })
  }

  general(gameForm: FormGroup) {
    return gameForm.get('general') as FormGroup
  }

  releaseDates(gameForm: FormGroup) {
    return gameForm.get('releaseDates') as FormArray
  }

  localization(gameForm: FormGroup) {
    return gameForm.get('localization') as FormArray
  }

  gameEdition(gameForm: FormGroup) {
    return this.general(gameForm).get('gameEdition') as FormGroup
  }

  categorization(gameForm: FormGroup) {
    return gameForm.get('categorization') as FormGroup
  }

  companies(gameForm: FormGroup) {
    return this.general(gameForm).get('companies') as FormGroup
  }

  createModel(gameForm: FormGroup):CreateGameDto {
    console.log(gameForm, this.categorization(gameForm))
    let model: CreateGameDto = {
      name: this.general(gameForm).get('name')?.value,
      story: gameForm.get('storyline')?.value,
      description: this.general(gameForm)?.get('description')?.value,
      gameStatus: this.general(gameForm)?.get('gameStatus')?.value,
      updateGameType: this.general(gameForm).get('updateGameType')?.value,
      updatedGameId : this.general(gameForm).get('updatedGameId')?.value, 
      //gameEdition:null,
      alternativeNames: [],
      gameLocalizations: [],
      gameGenres:[],
      gameThemes:[],
      gameModes:[],
      playerPerspectives:[],
      multiplayerModes:this.converToCreatemultiplayerModeDto(this.categorization(gameForm).get('multiplayerModes') as FormArray),
      releaseDates: this.converToCreateReleaseDateDto(this.releaseDates(gameForm)),
      websites: [],
      involvedCompanies: [],
      languageSupports:[],
      cover: this.general(gameForm).get('cover')?.value
    }

    // General game edition
    // if (this.gameEdition(gameForm).get('editionTitle')?.value!= null && this.gameEdition(gameForm).get('baseGame')?.value != null) {
    //   model.gameEdition = {
    //     editionTitle: this.gameEdition(gameForm).get('editionTitle')?.value,
    //     parentGameId: this.gameEdition(gameForm).get('baseGame')?.value,
    //   }
    // }

    // General game alternative name
    if (this.general(gameForm).get('gameAlternativeNames')?.value.length > 0) {
      model.alternativeNames = this.general(gameForm).get('gameAlternativeNames')?.value
    }

    // Localization
    if (this.localization(gameForm).value != null && this.localization(gameForm).value.length > 0) {
      this.localization(gameForm).value.forEach((entrie) => {
        let temp: CreateGameLocalizationDto = {
          regionId : entrie.region,
          localizedTitle : entrie.localizedTitle
        }
        model.gameLocalizations.push(temp)
      })
    }

    if (this.categorization(gameForm).get('genre')?.value != null ) {
      this.categorization(gameForm).get('genre')?.value.forEach((x) => {
        const temp: CreateGameGenreDto = {
          genreId: x
        }
        model.gameGenres.push(temp)
      }) 
    }

    if (this.categorization(gameForm).get('theme')?.value != null ) {
      this.categorization(gameForm).get('theme')?.value.forEach((x) => {
        const temp: CreateGameThemeDto = {
          themeId: x
        }
        model.gameThemes.push(temp)
      }) 
    }

    if (this.categorization(gameForm).get('gameMode')?.value != null ) {
      this.categorization(gameForm).get('gameMode')?.value.forEach((x) => {
        const temp: CreateGameModeDto = {
          gameModeId: x
        }
        model.gameModes.push(temp)
      }) 
    }

    if (this.categorization(gameForm).get('perspectives')?.value != null ) {
      this.categorization(gameForm).get('perspectives')?.value.forEach((x) => {
        const temp: CreateGamePlayerPerspectiveDto = {
          playerPerspectiveId: x
        }
        model.playerPerspectives.push(temp)
      }) 
    }

    return model;
  }

  converToCreatemultiplayerModeDto(list: FormArray) {
    let convertedResults: Array<CreateMultiplayerModeDto> = []
    let arrayTempValues = list.value
    if (arrayTempValues != null && arrayTempValues.length > 0) {
      arrayTempValues.forEach((entry) => {
          let tempReleaseDate: CreateMultiplayerModeDto = {
            campaignCoop: entry.coOpCampaign,
            dropIn: entry.dropInOut,
            lanCoop: entry.lanCoOp,
            offlineCoop:entry.offlineCoOp,
            offlineCoopMax: entry.offlineCoOpMax,
            offlineMax : entry.offlineMax,
            onlineCoop: entry.onlineCoOp,
            onlineCoopMax: entry.onlineCoOpMax,
            onlineMax : entry.onlineMax,
            splitScreen: entry.offlineSpliteScreen,
            splitScreenOnline :entry.onlineSplitScreen,
            platformId : entry.platform,
          }
          convertedResults.push(tempReleaseDate)
      });
    }
    return convertedResults;
  }

  converToCreateReleaseDateDto(list: FormArray) {
    let convertedResults: Array<CreateReleaseDateDto> = []
    let arrayTempValues = list.value
    if (arrayTempValues != null && arrayTempValues.length > 0) {
      arrayTempValues.forEach((entry) => {
        entry.releases.forEach(release => {
          let tempReleaseDate: CreateReleaseDateDto = {
            platformId: entry.platform,
            date: release.date,
            regionId: release.region,
            status: release.status
          }

          convertedResults.push(tempReleaseDate)
        });
      });
    }
    return convertedResults;
  }

  searchParentGame(searchInput: string){
    const body = JSON.stringify(searchInput)
    const params = new HttpParams().set('searchInput', searchInput)
    return this.http.post<any>(this.baseUrl + '/Search', null, { params })
  }

  createNewGame(model: CreateGameDto){
    return this.http.post<any>(this.baseUrl + '/AddGame',model)
  }

  listGame(){
    return this.http.get<Array<GameSimpleDto>>(this.baseUrl + '/GetAllGames')
  }

}