﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorVNPTQuiz.Models;

namespace BlazorVNPTQuiz.Repository
***REMOVED***
    public interface IRepositoryOntap
    ***REMOVED***
        public Task<List<Donvi>> LayDanhSachDonVi(int user_id);

        public Task<List<Category>> LayDanhSachChuDeTheoDonVi(int donvi_id);

        public Task GanChuDeChoDonVi(int donvi_id, List<Category> categories);

        public void GenerateDulieuOnTap(int donvi_id);
***REMOVED***
***REMOVED***